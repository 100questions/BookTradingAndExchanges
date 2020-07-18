package com.example.bookstore.room.dao;

import androidx.room.Dao;
import androidx.room.Insert;
import androidx.room.Query;
import androidx.room.Update;

import com.example.bookstore.model.Entity.Book;

import java.util.List;

import static androidx.room.OnConflictStrategy.IGNORE;
import static androidx.room.OnConflictStrategy.REPLACE;

@Dao
public interface BookDao {

    @Insert(onConflict = REPLACE)
    void insertBook(Book book);

    @Insert(onConflict = IGNORE)
    void insertOrReplaceBook(Book... books);

    @Update(onConflict = REPLACE)
    void updateBook(Book book);

    @Query("DELETE FROM Book")
    void deleteAll();

    @Query("SELECT * FROM Book")
    public List<Book> findAllBookSync();
}
