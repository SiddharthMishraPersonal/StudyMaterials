package com.example.firstapplication;

import android.R.integer;
import android.os.Bundle;
import android.app.Activity;
import android.view.Menu;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

public void tbnAddClick(View v) {
	// TODO Auto-generated method stub	
	TextView resultTxt = (TextView)findViewById(R.id.txtResult);
		try{
	
			EditText txtFirstNumber = (EditText)findViewById(R.id.txtNum01);
			EditText txtSecondNumber = (EditText)findViewById(R.id.txtNum02);

			
			Integer num1 = Integer.parseInt(txtFirstNumber.getText().toString());
			Integer num2 = Integer.parseInt(txtSecondNumber.getText().toString());


			Integer resultVal = num1+num2;			
			
			resultTxt.setText("Result : "+(resultVal).toString());
	}
		catch(Exception ex){			
			resultTxt.setText(ex.getMessage());
		}
}

    
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }
    
}
