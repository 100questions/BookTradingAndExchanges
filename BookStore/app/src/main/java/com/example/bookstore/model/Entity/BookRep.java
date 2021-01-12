package com.example.bookstore.model.Entity;

import androidx.annotation.NonNull;
import androidx.room.Ignore;
import androidx.room.PrimaryKey;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.io.Serializable;


public class BookRep implements Serializable {

    @NonNull
    @SerializedName("MASACH")
    @Expose
    private String bookId;
    @SerializedName("MANXB")
    @Expose
    private String publisherId;
    @SerializedName("TENSACH")
    @Expose
    private String bookName;
    @SerializedName("TACGIA")
    @Expose
    private String author;
    @SerializedName("THELOAI")
    @Expose
    private String categories;
    @SerializedName("GIABANSACH")
    @Expose
    private double price;
    @SerializedName("GIANHAPSACH")
    @Expose
    private double importingPrice;
    @SerializedName("SLTON")
    @Expose
    private int existingNumber;
    @SerializedName("IMG")
    @Expose
    private String imageBook;
    @SerializedName("LOAIBIA")
    @Expose
    private String coverTypes;
    @SerializedName("KICHTHUOC")
    @Expose
    private String size;
    @SerializedName("NGAYXUATBAN")
    @Expose
    private String publishDate;
    @SerializedName("SOTRANG")
    @Expose
    private int numberPage;
    @SerializedName("SoLuong")
    @Expose
    private int numberOrder;

    public int getNumberOrder() {
        return numberOrder;
    }

    public void setNumberOrder(int numberOrder) {
        this.numberOrder = numberOrder;
    }

    public BookRep() {
    }

    @Ignore
    public BookRep(BookRep book) {
        this.bookId = book.bookId;
        this.bookName = book.bookName;
        this.imageBook = book.imageBook;
        this.price = book.price;
        this.numberOrder = book.numberOrder;
    }

    public String getBookId() {
        return bookId;
    }

    public void setBookId(String bookId) {
        this.bookId = bookId;
    }

    public String getPublisherId() {
        return publisherId;
    }

    public void setPublisherId(String publisherId) {
        this.publisherId = publisherId;
    }

    public String getBookName() {
        return bookName;
    }

    public void setBookName(String bookName) {
        this.bookName = bookName;
    }

    public String getAuthor() {
        return author;
    }

    public void setAuthor(String author) {
        this.author = author;
    }

    public String getCategories() {
        return categories;
    }

    public void setCategories(String categories) {
        this.categories = categories;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public double getImportingPrice() {
        return importingPrice;
    }

    public void setImportingPrice(double importingPrice) {
        this.importingPrice = importingPrice;
    }

    public int getExistingNumber() {
        return existingNumber;
    }

    public void setExistingNumber(int existingNumber) {
        this.existingNumber = existingNumber;
    }

    public String getImageBook() {
        return imageBook;
    }

    public void setImageBook(String imageBook) {
        this.imageBook = imageBook;
    }

    public String getCoverTypes() {
        return coverTypes;
    }

    public void setCoverTypes(String coverTypes) {
        this.coverTypes = coverTypes;
    }

    public String getSize() {
        return size;
    }

    public void setSize(String size) {
        this.size = size;
    }

    public String getPublishDate() {
        return publishDate;
    }

    public void setPublishDate(String publishDate) {
        this.publishDate = publishDate;
    }

    public int getNumberPage() {
        return numberPage;
    }

    public void setNumberPage(int numberPage) {
        this.numberPage = numberPage;
    }
}
