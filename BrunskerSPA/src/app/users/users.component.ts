import { Component, OnInit, Input } from '@angular/core';
import { User } from '../_Model/user';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  @Input() user: User;

  constructor() { }

  ngOnInit() {
  }

}
