package com.example.bookstore.model.Entity;

import androidx.annotation.NonNull;
import androidx.room.Entity;
import androidx.room.Ignore;
import androidx.room.PrimaryKey;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

@Entity
public class User {

    @NonNull
    @PrimaryKey
    @SerializedName("MAKH")
    @Expose
    private String maKH;

    @SerializedName("TENKH")
    @Expose
    private String tenKH;

    @SerializedName("SODT")
    @Expose
    private String soDT;

    @SerializedName("DIACHI")
    @Expose
    private String diaChi;

    @SerializedName("GIOITINH")
    @Expose
    private Boolean gioiTinh;

    @SerializedName("MATKHAUDN")
    @Expose
    private String matKhauDN;

    public User(){

    };

    @Ignore
    public User(String maKH, String tenKH, String soDT, String diaChi, Boolean gioiTinh, String matKhauDN) {
        this.maKH = maKH;
        this.tenKH = tenKH;
        this.soDT = soDT;
        this.diaChi = diaChi;
        this.gioiTinh = gioiTinh;
        this.matKhauDN = matKhauDN;
    }

    public String getMaKH() {
        return maKH;
    }

    public void setMaKH(String maKH) {
        this.maKH = maKH;
    }

    public String getTenKH() {
        return tenKH;
    }

    public void setTenKH(String tenKH) {
        this.tenKH = tenKH;
    }

    public String getSoDT() {
        return soDT;
    }

    public void setSoDT(String soDT) {
        this.soDT = soDT;
    }

    public String getDiaChi() {
        return diaChi;
    }

    public void setDiaChi(String diaChi) {
        this.diaChi = diaChi;
    }

    public Boolean getGioiTinh() {
        return gioiTinh;
    }

    public void setGioiTinh(Boolean gioiTinh) {
        this.gioiTinh = gioiTinh;
    }

    public String getMatKhauDN() {
        return matKhauDN;
    }

    public void setMatKhauDN(String matKhauDN) {
        this.matKhauDN = matKhauDN;
    }
}
