package com.example.bookstore.room.dao;

import androidx.room.Dao;
import androidx.room.Insert;
import androidx.room.Query;
import androidx.room.Update;

import com.example.bookstore.model.CartItemModel;
import com.example.bookstore.model.Entity.User;

import java.util.ArrayList;
import java.util.List;

import static androidx.room.OnConflictStrategy.REPLACE;

@Dao
public interface UserDao {
    @Insert(onConflict = REPLACE)
    void InsertUser(User user);

    @Update(onConflict = REPLACE)
    void UpdateUserInfo(User user);

    @Query("UPDATE User SET tenKH = :userName, soDT= :phone, diaChi = :address, matKhauDN = :password, gioiTinh = :sex WHERE maKH =:id")
    void UpdateUser(String id, String userName, String phone, String password,String address, boolean sex);

    @Query("DELETE FROM User")
    public void Logout();

    @Query("SELECT * FROM User")
    public List<User> getUser();

}
