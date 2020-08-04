package com.example.bookstore.activity;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.SearchView;

import android.os.Bundle;
import android.util.TypedValue;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.AutoCompleteTextView;
import android.widget.CompoundButton;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.Toast;

import com.example.bookstore.R;
import com.google.android.material.chip.Chip;
import com.google.android.material.chip.ChipGroup;

public class SearchProductActivity extends AppCompatActivity {

    ChipGroup chipGroup;
    ImageView imgSearchBack;
    SearchView searchView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_search_product);
        getSupportActionBar().hide();
        init();
        setSearchviewTextSize(searchView,14);

        String [] mKeyHots = {"Đắc Nhân Tâm","Nhà Giả Kim","Tôi Tài Giỏi Bạn Cũng Thế","Giới Hạn Của Bạn Là Xuất Phát Điểm Của Tôi"};
        try {
            for (String key: mKeyHots)
            {
                Chip newChip = addNewChip(key);
                // Set Listener for the Chip:
                newChip.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
                    @Override
                    public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                        handleChipCheckChanged((Chip) buttonView, isChecked);
                    }
                });

                newChip.setOnCloseIconClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        handleChipCloseIconClicked((Chip) v);
                    }
                });
            }
        }catch (Exception ex)
        {
            Toast.makeText(this,ex.getMessage(),Toast.LENGTH_LONG).show();
        }

        searchView.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(String query) {
                return false;
            }

            @Override
            public boolean onQueryTextChange(String newText) {
                return false;
            }
        });

        imgSearchBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish();
            }
        });
    }

    private void init()
    {
        chipGroup = (ChipGroup) findViewById(R.id.chipGroup);
        imgSearchBack = (ImageView) findViewById(R.id.btnSearchBack);
        searchView = (SearchView) findViewById(R.id.product_search_view);
    }

    private Chip addNewChip(String key)
    {
        LayoutInflater inflater = LayoutInflater.from(this);
        Chip newChip = (Chip) inflater.inflate(R.layout.chip_entry, this.chipGroup, false);
        newChip.setText(key);
        this.chipGroup.addView(newChip);
        return newChip;
    }

    private void handleChipCloseIconClicked(Chip chip) {
        ChipGroup parent = (ChipGroup) chip.getParent();
        parent.removeView(chip);
    }

    // Chip Checked Changed
    private void handleChipCheckChanged(Chip chip, boolean isChecked) {
        searchView.setQuery(chip.getText(),false);
        handleChipCloseIconClicked(chip);
    }

    private void setSearchviewTextSize(SearchView searchView, int fontSize) {
        try {
            AutoCompleteTextView autoCompleteTextViewSearch = (AutoCompleteTextView) searchView.findViewById(searchView.getContext().getResources().getIdentifier("app:id/search_src_text", null, null));
            if (autoCompleteTextViewSearch != null) {
                autoCompleteTextViewSearch.setTextSize(TypedValue.COMPLEX_UNIT_SP, fontSize);
            } else {
                LinearLayout linearLayout1 = (LinearLayout) searchView.getChildAt(0);
                LinearLayout linearLayout2 = (LinearLayout) linearLayout1.getChildAt(2);
                LinearLayout linearLayout3 = (LinearLayout) linearLayout2.getChildAt(1);
                AutoCompleteTextView autoComplete = (AutoCompleteTextView) linearLayout3.getChildAt(0);
                autoComplete.setTextSize(TypedValue.COMPLEX_UNIT_SP, fontSize);
            }
        } catch (Exception e) {
            LinearLayout linearLayout1 = (LinearLayout) searchView.getChildAt(0);
            LinearLayout linearLayout2 = (LinearLayout) linearLayout1.getChildAt(2);
            LinearLayout linearLayout3 = (LinearLayout) linearLayout2.getChildAt(1);
            AutoCompleteTextView autoComplete = (AutoCompleteTextView) linearLayout3.getChildAt(0);
            autoComplete.setTextSize(TypedValue.COMPLEX_UNIT_SP, fontSize);
        }
    }
}
