import { Component, OnInit } from '@angular/core';
import { UserViewModel, UserBO, TopColoursBO, AgesBO } from '../models/user';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent  implements OnInit {

  userBOs: UserBO[] = [];
  topColoursBOs: TopColoursBO[] = [];
  agesBOs: AgesBO[] = [];

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.userService.getUserColorAndAgeDetails().subscribe((usersDetails) => {
      this.userBOs = usersDetails.userBOs;
      this.topColoursBOs = usersDetails.topColoursBOs;
      this.agesBOs = usersDetails.agesBOs;

      console.log("User Details", this.userBOs);
      console.log("color Count", this.topColoursBOs);
      console.log("color Count", this.agesBOs);
    });
  }

  
  onUserHover(index: number) {
    this.userBOs[index].IsHovered = true;
  }

  onUserLeave(index: number) {
    this.userBOs[index].IsHovered = false;
  }

  refreshData(){
    this.loadUsers();
  }
}