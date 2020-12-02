package com.example.bookstore.api;


import com.example.bookstore.model.Entity.Bill;
import com.example.bookstore.model.Entity.BillDetail;
import com.example.bookstore.model.Entity.Book;
import com.example.bookstore.model.Entity.Category;
import com.example.bookstore.model.Entity.User;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Path;

public interface RequestAPI {
    // Book
    @GET("api/Sach")
    Call<ArrayList<Book>> getAllBook();

    @GET("api/Sach/ChiTiet/{maKH}")
    Call<ArrayList<Book>> getListBook(@Path("maKH") String maKH);

    @GET("api/Sach/{ma}")
    Call<Book> GetBook(@Path("ma") String ma);

    // Book Category
    @GET("api/LoaiSach")
    Call<ArrayList<Category>> getCategory();

    //User
    @POST("api/KhachHang")
    Call<String> createUser(@Body User user);

    @GET("api/KhachHang/{tk}/{mk}")
    Call<User> Login(@Path("tk") String tk,@Path("mk") String mk);

    @GET("api/HoaDon/KhachHang/{maKH}")
    Call<ArrayList<Bill>> GetListBill(@Path("maKH") String maKH);

    @GET("api/ChiTietHoaDon/{maHD}")
    Call<List<BillDetail>> GetListBillDetail(@Path("maHD") String maHD);

    //Hoa Don
    @POST("api/HoaDon")
    Call<String> CreateBill(@Body Bill bill);

    @POST("api/ChiTietHoaDon")
    Call<String> CreateBillDetail(@Body BillDetail billDetail);

}
