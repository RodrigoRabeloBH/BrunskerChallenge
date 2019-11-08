import { Component, OnInit } from '@angular/core';
import { User } from '../_Model/user';
import { UserService} from '../_Services/user.service';
import { AlertifyService } from '../_Services/Alertify.service';


@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  users: User[];

  constructor(private user: UserService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadUsers();
  }

loadUsers() {
  this.user.getUsers().subscribe((users: User[]) => {
    this.users = users;
    console.log(users);
  }, error => {
    this.alertify.error('Something went wrong!');
  });
 }
}
