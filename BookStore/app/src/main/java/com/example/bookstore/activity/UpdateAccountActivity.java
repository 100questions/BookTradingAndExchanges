package com.example.bookstore.activity;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.RadioButton;

import com.example.bookstore.R;
import com.example.bookstore.api.APIClient;
import com.example.bookstore.api.RequestAPI;
import com.example.bookstore.model.Entity.User;
import com.example.bookstore.room.database.AppDatabase;
import com.google.android.material.snackbar.Snackbar;

import java.util.UUID;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class UpdateAccountActivity extends AppCompatActivity {

    private EditText edtName,edtPhoneNumber, edtAddress, edtPassword;
    private RadioButton rdMale, rdFeMale;
    private Button btnUpdateUser;
    private ImageView btnUpdateAccountBack;
    private RequestAPI requestAPI;
    private AppDatabase mDB;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_update_account);
        init();
        final User user = mDB.UseDao().getUser().get(0);

        Call<User> call = requestAPI.getUserByID(user.getMaKH());
        call.enqueue(new Callback<User>() {
            @Override
            public void onResponse(Call<User> call, Response<User> response) {
                if(response.isSuccessful()){
                    edtName.setText(response.body().getTenKH());
                    edtPhoneNumber.setText(response.body().getSoDT());
                    edtAddress.setText(response.body().getDiaChi());
                    edtPassword.setText(response.body().getMatKhauDN());
                    rdMale.setChecked(response.body().getGioiTinh());
                }
            }

            @Override
            public void onFailure(Call<User> call, Throwable t) {

            }
        });

        btnUpdateUser.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                final String userID = user.getMaKH();
                final String userName = edtName.getText().toString();
                final String phoneNumber = edtPhoneNumber.getText().toString();
                final String address = edtAddress.getText().toString();
                final String password = edtPassword.getText().toString();
                final boolean sex = rdMale.isChecked();
                //
                final User userUpdate = new User(userID,userName,phoneNumber,address,sex,password);
                Call<String> call = requestAPI.updateUser(userUpdate,userUpdate.getMaKH());
                call.enqueue(new Callback<String>() {
                    @Override
                    public void onResponse(Call<String> call, Response<String> response) {
                        if(response.isSuccessful())
                        {
                            mDB.UseDao().UpdateUserInfo(userUpdate);
                            Intent intent = new Intent(UpdateAccountActivity.this, MainActivity.class);
                            intent.putExtra("isUpdateUser",true);
                            startActivity(intent);
                            View view = findViewById(R.id.btnUpdate);
                            ShowSnackBar(view,"Update Thành Công",Snackbar.LENGTH_LONG);

                        }
                        Log.d("TAG","Response = "+ response.body());
                    }

                    @Override
                    public void onFailure(Call<String> call, Throwable t) {
                        Log.d("TAG","Response = "+t.toString());
                        View view = findViewById(R.id.btnUpdate);
                        ShowSnackBar(view,"Update fail",Snackbar.LENGTH_LONG);
                    }
                });
            }
        });

        btnUpdateAccountBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        });

    }

    private void ShowSnackBar(View view, String message, int duration)
    {
        Snackbar.make(view,message,duration).show();
    }

    private void init()
    {
        edtName = findViewById(R.id.edtUpdateName);
        edtPhoneNumber = findViewById(R.id.edtUpdatePhone);
        edtAddress = findViewById(R.id.edtUpdateAddress);
        edtPassword = findViewById(R.id.edtUpdatePassWord);
        rdFeMale = findViewById(R.id.rdUpdateFeMale);
        rdMale = findViewById(R.id.rdUpdateMale);
        btnUpdateUser = findViewById(R.id.btnUpdate);
        btnUpdateAccountBack= findViewById(R.id.btnUpdateAccountBack);
        mDB = AppDatabase.BuilderDatabase(this);
        requestAPI = APIClient.getClient().create(RequestAPI.class);
    }
}