package com.example.bookstore.fragment;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;

import com.example.bookstore.R;
import com.example.bookstore.activity.MainActivity;
import com.example.bookstore.api.APIClient;
import com.example.bookstore.api.RequestAPI;
import com.example.bookstore.model.Entity.User;
import com.example.bookstore.room.database.AppDatabase;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

/**
 * A simple {@link Fragment} subclass.
 */
public class LoginFragment extends Fragment {
    Button btnAuthentication;
    EditText  edtPhoneNumber,edtPassword;
    RequestAPI requestAPI;
    AppDatabase mDB;
    public LoginFragment() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_login, container, false);
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        init(view);

        btnAuthentication.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String phoneNumber = edtPhoneNumber.getText().toString();
                String passWord = edtPassword.getText().toString();
                Call<User> call = requestAPI.Login(phoneNumber,passWord);
                call.enqueue(new Callback<User>() {
                    @Override
                    public void onResponse(Call<User> call, Response<User> response) {
                        if(response.isSuccessful())
                        {
                            mDB.UseDao().InsertUser(response.body());
                            SharedPreferences sharedPreferences = getActivity().getSharedPreferences("Logged", Context.MODE_PRIVATE);
                            SharedPreferences.Editor editor = sharedPreferences.edit();
                            editor.putBoolean("IsLogged",true);
                            editor.apply();
                            Intent intent = new Intent(requireContext(), MainActivity.class);
                            intent.putExtra("IsLogged",true);
                            startActivity(intent);
                        }
                    }

                    @Override
                    public void onFailure(Call<User> call, Throwable t) {
                        Log.i("Loggin",t.getMessage());
                    }
                });
            }
        });
    }

    private void init(View view) {
        requestAPI = APIClient.getClient().create(RequestAPI.class);
        mDB = AppDatabase.BuilderDatabase(requireContext());
        btnAuthentication = view.findViewById(R.id.btnAuthentication);
        edtPhoneNumber = view.findViewById(R.id.edt_phone_number_login);
        edtPassword = view.findViewById(R.id.edt_password_login);
    }
}
