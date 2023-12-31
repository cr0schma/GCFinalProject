import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, } from '@angular/forms';
import { GrandClickrDbService } from '../grand-clickr-db.service';
import { LoginInfo } from '../login-info';
import { Router, } from '@angular/router'
import { AzBlobService } from '../az-blob.service';

declare var window: any;

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent {

  constructor(private formBuilder: FormBuilder, private grandClickerDbService: GrandClickrDbService, private azBlobService: AzBlobService, private router: Router) {
    this.validation = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  validation: FormGroup;
  toastNotification: any;
  
  toastTrigger() {
    this.toastNotification = new window.bootstrap.Toast(
      document.getElementById("liveToast")
    );
    this.toastNotification.show();
  }

  onSubmit() {

    if (this.validation.valid) {

      const loginInfo: LoginInfo = this.validation.value;
      
      const userName: string = loginInfo.userName;
      const password: string = loginInfo.password;

      this.grandClickerDbService.UserLoginValidation(userName, password).subscribe(result => {
        if (result === true){
          localStorage.setItem("userName", userName)
          this.router.navigate(['/az-storage'])
        }
        if (result === false){
          this.toastTrigger()
        }
      }
      );
      
    }
  }
  


}
