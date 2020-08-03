package com.example.bookstore.model.Entity;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class BillDetail {
    @SerializedName("MAHD")
    @Expose
    public String mAHD;
    @SerializedName("MASP")
    @Expose
    public String mASP;
    @SerializedName("SOLUONGMUA")
    @Expose
    public Integer sOLUONGMUA;
    @SerializedName("DONGIABAN")
    @Expose
    public Double dONGIABAN;
    @SerializedName("TONGTIEN")
    @Expose
    public Double tONGTIEN;

    public BillDetail(){}

    public BillDetail(String mAHD, String mASP, Integer sOLUONGMUA, Double dONGIABAN, Double tONGTIEN) {
        this.mAHD = mAHD;
        this.mASP = mASP;
        this.sOLUONGMUA = sOLUONGMUA;
        this.dONGIABAN = dONGIABAN;
        this.tONGTIEN = tONGTIEN;
    }

    public String getmAHD() {
        return mAHD;
    }

    public void setmAHD(String mAHD) {
        this.mAHD = mAHD;
    }

    public String getmASP() {
        return mASP;
    }

    public void setmASP(String mASP) {
        this.mASP = mASP;
    }

    public Integer getsOLUONGMUA() {
        return sOLUONGMUA;
    }

    public void setsOLUONGMUA(Integer sOLUONGMUA) {
        this.sOLUONGMUA = sOLUONGMUA;
    }

    public Double getdONGIABAN() {
        return dONGIABAN;
    }

    public void setdONGIABAN(Double dONGIABAN) {
        this.dONGIABAN = dONGIABAN;
    }

    public Double gettONGTIEN() {
        return tONGTIEN;
    }

    public void settONGTIEN(Double tONGTIEN) {
        this.tONGTIEN = tONGTIEN;
    }
}
