import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-my-info',
  templateUrl: './my-info.component.html',
  styleUrls: ['./my-info.component.css']
})
export class MyInfoComponent implements OnInit {
  public qrCodeText!: string;

  constructor() { }

  ngOnInit(): void {
  }

  writeMyInfo(){
    return this.qrCodeText =" I have used my skills in 'Frontend' as well as 'Backend'. The 'to-do' list is not that big, but my passion has made me do it with love and take my imagination to design a fancy layout as well. It worth! - Created by: OMRAN";
  }

}
