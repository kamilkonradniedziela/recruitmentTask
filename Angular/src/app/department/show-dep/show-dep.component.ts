import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-dep',
  templateUrl: './show-dep.component.html',
  styleUrls: ['./show-dep.component.css']
})
export class ShowDepComponent implements OnInit {

  constructor(private service:SharedService) { }

  DepartmentList:any=[];

  ModalTitle:string;
  ActivateAddEditDepComp:boolean=false;
  dep:any;

  ngOnInit(): void {
    this.refreshDepList();
  }

addClick()
{
  this.dep={
    id:0,
    name:""
  }
  this.ModalTitle="Dodaj dział";
  this.ActivateAddEditDepComp=true;
}

editClick(item)
{
  this.dep=item;
  this.ModalTitle="Edytuj dział";
  this.ActivateAddEditDepComp=true;
}

deleteClick(item)
{
  if(confirm('Jesteś pewny?'))
  {
    this.service.deleteDepartment(item.id).subscribe(data=>{
      alert(data.toString());
      this.refreshDepList();
    })
  }
}

closeClick()
{
  this.ActivateAddEditDepComp=false;
  this.refreshDepList();
}

  refreshDepList()
  {
    this.service.getDepList().subscribe(data=>{this.DepartmentList=data;})
  }

}
