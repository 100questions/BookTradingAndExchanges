package com.example.bookstore.model;

import androidx.room.Entity;
import androidx.room.Ignore;

import com.example.bookstore.model.Entity.Book;

import java.io.Serializable;

@Entity
public class CartItemModel extends Book {
    private int soluong = 1;
    private double sumPrice;

    public CartItemModel()
    {
    }

    @Ignore
    public CartItemModel(Book book) {
        super(book);
    }

    public int getSoluong() {
        return soluong;
    }

    public void setSoluong(int soluong) {
        this.soluong = soluong;
    }

    public double getSumPrice() {
        sumPrice = getPrice() * soluong;
        return sumPrice;
    }

    public void setSumPrice(double sumPrice) {
        this.sumPrice = sumPrice;
    }
}
