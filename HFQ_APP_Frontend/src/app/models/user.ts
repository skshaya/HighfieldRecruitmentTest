export class UserBO {
  Id: string = '';
  FirstName: string = '';
  LastName: string = '';
  Email: string = '';
  Dob: Date = new Date();
  FavouriteColour: string = '';
  IsHovered : boolean = false;
  agesBO: AgesBO = new AgesBO(); // Initialize an instance of AgesBO 
}

export class AgesBO {
  UserId : Number = 0;
  OriginalAge: string = '';
  AgePlusTwenty: string = '';
}

export class TopColoursBO {
  Count : Number = 0;
  Colour: string = '';
}
export class UserViewModel{
  userBOs : UserBO[] = [];
  topColoursBOs : TopColoursBO[] = [];
  agesBOs : AgesBO[] = [];
}