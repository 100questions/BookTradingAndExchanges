package com.example.bookstore.room.dao;

import androidx.room.Dao;
import androidx.room.Insert;
import androidx.room.Query;

import com.example.bookstore.model.Entity.User;

import java.util.ArrayList;
import java.util.List;

import static androidx.room.OnConflictStrategy.REPLACE;

@Dao
public interface UserDao {
    @Insert(onConflict = REPLACE)
    void InsertUser(User user);

    @Query("DELETE FROM User")
    public void Logout();

    @Query("SELECT * FROM User")
    public List<User> getUser();

}
