import { Component, OnInit, Input } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-dep',
  templateUrl: './add-edit-dep.component.html',
  styleUrls: ['./add-edit-dep.component.css']
})
export class AddEditDepComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() dep:any;
  id:string;
  name:string;

  ngOnInit(): void {
    this.id=this.dep.id;
    this.name=this.dep.name;
  }

  addDepartment(){
    var val = {id:this.id,
      name:this.name};
    this.service.addDepartment(val).subscribe(res=>{
      alert(res.toString());
    });
  }

  updateDepartment(){
    var val = {id:this.id,
      name:this.name};
    this.service.updateDepartment(val).subscribe(res=>{
    alert(res.toString());
    });
  }

}
