package com.example.bookstore.model.Entity;

import com.google.gson.annotations.SerializedName;

public class Category {

    @SerializedName("MALS")
    private String maLoai;

    @SerializedName("TENLS")
    private String tenLoai;

    public Category(String maLoai, String tenLoai) {
        this.maLoai = maLoai;
        this.tenLoai = tenLoai;
    }

    public String getMaLoai() {
        return maLoai;
    }

    public void setMaLoai(String maLoai) {
        this.maLoai = maLoai;
    }

    public String getTenLoai() {
        return tenLoai;
    }

    public void setTenLoai(String tenLoai) {
        this.tenLoai = tenLoai;
    }
}
