import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_Services/Auth.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
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
      fullName: new FormControl('', [Validators.required, Validators.maxLength(120), Validators.minLength(3)]),
      nickname : new FormControl('', [Validators.required, Validators.maxLength(60), Validators.minLength(3)]),
      password: new FormControl('', [Validators.required, Validators.maxLength(12), Validators.minLength(4)]),
      email: new FormControl('', [Validators.required, Validators.maxLength(120), Validators.minLength(7)]),
      document: new FormControl('', [Validators.required, Validators.maxLength(11), Validators.minLength(11)]),
      gender: new FormControl('', [Validators.required, Validators.maxLength(9), Validators.minLength(4)]),
      city: new FormControl('', [Validators.required, Validators.maxLength(30), Validators.minLength(3)]),
      state: new FormControl('', [Validators.required, Validators.maxLength(30), Validators.minLength(2)]),
      zipcode: new FormControl('', [Validators.required, Validators.maxLength(9), Validators.minLength(9)]),
      dateOfBirth: new FormControl('', Validators.required),
      phone: new FormControl('', [Validators.required, Validators.maxLength(10), Validators.minLength(10)]),
      cellPhone: new FormControl('', [Validators.required, Validators.maxLength(11), Validators.minLength(11)]),
      image: new FormControl('', [Validators.required, Validators.maxLength(200), Validators.minLength(5)])
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
