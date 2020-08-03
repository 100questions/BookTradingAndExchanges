package com.example.bookstore.model.Entity;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Bill {
    @SerializedName("MAHD")
    @Expose
    public String mAHD;
    @SerializedName("MAKH")
    @Expose
    public String mAKH;
    @SerializedName("NGAYLAPHD")
    @Expose
    public String nGAYLAPHD;
    @SerializedName("THANHTIEN")
    @Expose
    public Double tHANHTIEN;
    @SerializedName("TRANGTHAI")
    @Expose
    public String tRANGTHAI;

    public Bill(){}

    public Bill(String mAHD, String mAKH, String nGAYLAPHD, Double tHANHTIEN, String tRANGTHAI) {
        this.mAHD = mAHD;
        this.mAKH = mAKH;
        this.nGAYLAPHD = nGAYLAPHD;
        this.tHANHTIEN = tHANHTIEN;
        this.tRANGTHAI = tRANGTHAI;
    }

    public String getmAHD() {
        return mAHD;
    }

    public void setmAHD(String mAHD) {
        this.mAHD = mAHD;
    }

    public String getmAKH() {
        return mAKH;
    }

    public void setmAKH(String mAKH) {
        this.mAKH = mAKH;
    }

    public String getnGAYLAPHD() {
        return nGAYLAPHD;
    }

    public void setnGAYLAPHD(String nGAYLAPHD) {
        this.nGAYLAPHD = nGAYLAPHD;
    }

    public Double gettHANHTIEN() {
        return tHANHTIEN;
    }

    public void settHANHTIEN(Double tHANHTIEN) {
        this.tHANHTIEN = tHANHTIEN;
    }

    public String gettRANGTHAI() {
        return tRANGTHAI;
    }

    public void settRANGTHAI(String tRANGTHAI) {
        this.tRANGTHAI = tRANGTHAI;
    }
}
