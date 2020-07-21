package com.example.bookstore.room.database;

import android.content.Context;

import androidx.room.Database;
import androidx.room.Room;
import androidx.room.RoomDatabase;

import com.example.bookstore.model.CartItemModel;
import com.example.bookstore.model.Entity.Book;
import com.example.bookstore.room.dao.BookDao;
import com.example.bookstore.room.dao.CartBookDao;

@Database(entities = {CartItemModel.class}, version = 1,exportSchema = false)
public abstract class AppDatabase extends RoomDatabase {
    private static AppDatabase INSTANCE;
    public  abstract CartBookDao cartBookDao();
    public static AppDatabase BuilderDatabase(Context context) {
        if (INSTANCE == null) {
            INSTANCE = Room.databaseBuilder(context,AppDatabase.class,"Book")
                    .allowMainThreadQueries()
                    .fallbackToDestructiveMigration()
                    .build();
        }
        return INSTANCE;
    }
//    public static void destroyInstance() {
//        INSTANCE = null;
//    }
}
