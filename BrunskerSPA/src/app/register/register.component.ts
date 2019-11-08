import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_Services/Auth.service';
import { FormGroup, FormControl } from '@angular/forms';
import { User } from '../_Model/user';
import { Router } from '@angular/router';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  user: User;
  registerForm: FormGroup;

  constructor(private authService: AuthService, private alertifyService: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.registerForm = new FormGroup({
      fullname: new FormControl(),
      nickname : new FormControl(),
      password: new FormControl(),
      email: new FormControl(),
      document: new FormControl(),
      gender: new FormControl(),
      city: new FormControl(),
      state: new FormControl(),
      zipcode: new FormControl(),
      birthdate: new FormControl(),
      phone: new FormControl(),
      cellphone: new FormControl(),
      image: new FormControl()
    });
  }
  register() {
    if (this.registerForm.valid) {
      this.user = Object.assign({}, this.registerForm.value);
      this.authService.register(this.user).subscribe(() => {
        this.alertifyService.success('Registration successful');
      }, err => {
        this.alertifyService.error('Something went wrong');
      }, () => {
        this.authService.login(this.user).subscribe(() => {
          this.router.navigate(['/list']);
        });
      });
    }
  }
}
