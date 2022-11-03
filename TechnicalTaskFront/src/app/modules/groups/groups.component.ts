import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { GroupsService } from 'src/app/data/service/groups.service';


@Component({
  selector: 'groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.scss']
})
export class GroupsComponent implements OnInit {
  groupForm : FormGroup | any;
  constructor(private fb: FormBuilder, private groupsService:GroupsService) { }
  @Output() groupAdd = new EventEmitter<any>();
  ngOnInit() {
    this.initForm();
  }

  private initForm() {
    this.groupForm = this.fb.group({
      arabicName: new FormControl(),
      englishName: new FormControl()
    });
  }

  onSubmit(){
    this.groupsService.addGroup(this.groupForm.value).subscribe(res=>{
      if (res.status) {
        this.groupAdd.emit(res.message);
      }
    })
  }

}
