package com.example.bookstore.model;

public class CartItemModel extends Product {
    private int soluong = 0;

    public CartItemModel(String productName, double price, int imgProduct,int soLuong) {
        super(productName, price, imgProduct);
        this.soluong = soLuong;
    }

    public int getSoluong() {
        return soluong;
    }

    public void setSoluong(int soluong) {
        this.soluong = soluong;
    }
}
