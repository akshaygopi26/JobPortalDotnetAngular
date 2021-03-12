import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { forEach as _forEach, includes as _includes, map as _map } from 'lodash-es';
import { AppComponentBase } from '@shared/app-component-base';
import {
  JobServiceProxy,
  UserDto,
  RoleDto,
  CreateJobInput,
  UpdateJobInputDTO
} from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-edit-job',
  templateUrl: './edit-job.component.html',
  styleUrls: ['./edit-job.component.css']
})
export class EditJobComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  job = new UpdateJobInputDTO();
  //roles: RoleDto[] = [];
  //checkedRolesMap: { [key: string]: boolean } = {};
  id: number;
  jobDetails = new UpdateJobInputDTO();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _jobService: JobServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    // this._jobService.get(this.id).subscribe((result) => {
    //   this.job = result;

    //   this._userService.getRoles().subscribe((result2) => {
    //     this.roles = result2.items;
    //     this.setInitialRolesStatus();
    //   });
    // });
    this.job=this.jobDetails;

  }

  // setInitialRolesStatus(): void {
  //   _map(this.roles, (item) => {
  //     this.checkedRolesMap[item.normalizedName] = this.isRoleChecked(
  //       item.normalizedName
  //     );
  //   });
  // }

  // isRoleChecked(normalizedName: string): boolean {
  //   return _includes(this.user.roleNames, normalizedName);
  // }

  // onRoleChange(role: RoleDto, $event) {
  //   this.checkedRolesMap[role.normalizedName] = $event.target.checked;
  // }

  // getCheckedRoles(): string[] {
  //   const roles: string[] = [];
  //   _forEach(this.checkedRolesMap, function (value, key) {
  //     if (value) {
  //       roles.push(key);
  //     }
  //   });
  //   return roles;
  // }

  save(): void {
    this.saving = true;

    //this.user.roleNames = this.getCheckedRoles();
    console.log(this.job);
    console.log(this.jobDetails);
    this._jobService
      .updateJob(this.job)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('UpdatedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }
}
