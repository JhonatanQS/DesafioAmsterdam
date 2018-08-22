import { Component, OnInit } from '@angular/core';
import { read } from 'fs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';
  csvRecords = [];

  ngOnInit() {

  }

  fileloaded($event): void {
    var input = $event.target;
    var reader = new FileReader();
    reader.readAsText(input.files[0]);

    reader.onload = (data) => {
      let DataArray = reader.result.split(/\r\n|\n/);

      let headers = DataArray[0].split(",");
      let headerArray = [];
      for (let j = 0; j < headers.length; j++) {
        headerArray.push(headers[j]);
      }


      for (let i = 0; i < DataArray.length; i++) {
        let data = DataArray[i].split(",");

        if (data.length != headerArray.length) {
          // if(data==""){
          //     alert("Extra blank line is present at line number "+i+", please remove it.");
          //     return null;
          // }else{
          if (data != "") {
            alert("Record at line number " + i + " contain " + data.length + " tokens, and is not matching with header length of :" + headerArray.length);
            return null;
          }
        }

        let col = [];
        for (let j = 0; j < data.length; j++) {
          if (data != "")
            col.push(data[j]);
        }
        this.csvRecords.push(col);
      }
    }
  }
}
