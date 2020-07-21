package com.example.bookstore.room.dao;

import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Insert;
import androidx.room.Query;
import androidx.room.Update;

import com.example.bookstore.model.CartItemModel;

import java.util.ArrayList;
import java.util.List;

import static androidx.room.OnConflictStrategy.REPLACE;

@Dao
public interface CartBookDao {
    @Insert(onConflict = REPLACE)
    void InsertCartBook(CartItemModel cartBook);

    @Update(onConflict = REPLACE)
    void UpdateCartBook(CartItemModel cartBook);

    @Query("DELETE FROM CartItemModel")
    void deleteAll();

    @Query("SELECT * FROM CartItemModel")
    public List<CartItemModel> findAllCartBookSync();

    @Query("SELECT * FROM CartItemModel WHERE bookId = :id")
    public CartItemModel getCartBook(String id);

    @Query("DELETE FROM CartItemModel WHERE bookId = :id")
    void DeleteCartBook(String id);


}
