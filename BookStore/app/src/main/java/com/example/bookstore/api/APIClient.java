package com.example.bookstore.api;

import okhttp3.OkHttpClient;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class APIClient {

    public static String BASE_URL = "http://10.0.2.2/";

    private static Retrofit retrofit;
    public static Retrofit getClient(){

        OkHttpClient httpClient = new OkHttpClient.Builder().build();

        if(retrofit == null){
            retrofit = new Retrofit.Builder()
                    .baseUrl(BASE_URL)
                    .client(httpClient)
                    .addConverterFactory(GsonConverterFactory.create())
                    .build();
        }
        return retrofit;

//        Gson gson = new GsonBuilder()
//                .setLenient()
//                .create();
//
//        if (retrofit == null) {
//            retrofit = new Retrofit.Builder()
//                    .baseUrl(BASE_URL)
//                    .addConverterFactory(GsonConverterFactory.create(gson))
//                    .build();
//        }
//        return retrofit;
    }
}
