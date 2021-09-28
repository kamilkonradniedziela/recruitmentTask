import { Component, OnInit, Input } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-con',
  templateUrl: './add-edit-con.component.html',
  styleUrls: ['./add-edit-con.component.css']
})
export class AddEditConComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() con:any;
  id:string;
  name:string;
  surname:string;
  city:string;
  departmentName:string;
  dateOfBirth:string;

  DepartmentsList:any=[];

  ngOnInit(): void {
    this.loadDepartmentList();
  }

  loadDepartmentList(){
    this.service.getAllDepartmentNames().subscribe((data:any)=>{
      this.DepartmentsList=data;

      this.id=this.con.id;
      this.name=this.con.name;
      this.surname=this.con.surname;
      this.city=this.con.city;
      this.departmentName=this.con.departmentName;
      this.dateOfBirth=this.con.dateOfBirth;
    });
  }

  addContractor(){
    var val = {id:this.id,
              name:this.name,
              surname:this.surname,
              city:this.city,
              departmentName:this.departmentName,
              dateOfBirth:this.dateOfBirth};
    this.service.addContractor(val).subscribe(res=>{
      alert(res.toString());
    });
  }

  updateContractor(){
    var val = {id:this.id,
              name:this.name,
              surname:this.surname,
              city:this.city,
              departmentName:this.departmentName,
              dateOfBirth:this.dateOfBirth};
    this.service.updateContractor(val).subscribe(res=>{
    alert(res.toString());
    });
  }

}
