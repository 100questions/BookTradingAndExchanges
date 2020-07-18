package com.example.bookstore.model;

public class Product {
    private String productName;
    private double price;
    private int imgProduct;

    public Product(String productName, double price, int imgProduct) {
        this.productName = productName;
        this.price = price;
        this.imgProduct = imgProduct;
    }

    public String getProductName() {
        return productName;
    }

    public void setProductName(String productName) {
        this.productName = productName;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public int getImgProduct() {
        return imgProduct;
    }

    public void setImgProduct(int imgProduct) {
        this.imgProduct = imgProduct;
    }
}
