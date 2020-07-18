package com.example.bookstore.api;


import com.example.bookstore.model.Entity.Book;
import com.example.bookstore.model.Entity.Category;
import com.example.bookstore.model.Entity.User;

import java.util.ArrayList;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Path;

public interface RequestAPI {
    // Book
    @GET("api/Sach")
    Call<ArrayList<Book>> getAllBook();

    @GET("api/Sach/{ma}")
    Call<Book> GetBook(@Path("ma") String ma);

    // Book Category
    @GET("api/LoaiSach")
    Call<ArrayList<Category>> getCategory();

    //User
    @POST("api/KhachHang")
    Call<String> createUser(@Body User user);

}
