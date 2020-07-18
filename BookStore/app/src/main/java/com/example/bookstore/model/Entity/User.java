package com.example.bookstore.model.Entity;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class User {

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

    public User(String maKH, String tenKH, String soDT, String diaChi, Boolean gioiTinh, String matKhauDN) {
        this.maKH = maKH;
        this.tenKH = tenKH;
        this.soDT = soDT;
        this.diaChi = diaChi;
        this.gioiTinh = gioiTinh;
        this.matKhauDN = matKhauDN;
    }

    public String getMAKH() {
        return maKH;
    }

    public void setMAKH(String mAKH) {
        this.maKH = mAKH;
    }

    public String getTENKH() {
        return tenKH;
    }

    public void setTENKH(String tENKH) {
        this.tenKH = tENKH;
    }

    public String getSODT() {
        return soDT;
    }

    public void setSODT(String sODT) {
        this.soDT = sODT;
    }

    public String getDIACHI() {
        return diaChi;
    }

    public void setDIACHI(String dIACHI) {
        this.diaChi = dIACHI;
    }

    public Boolean getGIOITINH() {
        return gioiTinh;
    }

    public void setGIOITINH(Boolean gIOITINH) {
        this.gioiTinh = gIOITINH;
    }

    public String getMATKHAUDN() {
        return matKhauDN;
    }

    public void setMATKHAUDN(String mATKHAUDN) {
        this.matKhauDN = mATKHAUDN;
    }

}
