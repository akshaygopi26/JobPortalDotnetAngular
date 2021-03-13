import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from 'shared/paged-listing-component-base';
import {
  AppliedJobListDTO,
  AppliedJobsServiceProxy,
  UserDto,
  UserDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
import { CreateAppliedJobComponent } from './create-applied-job/create-applied-job.component';

class PagedUsersRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  selector: 'app-appliedjobs',
  templateUrl: './appliedjobs.component.html',
  styleUrls: ['./appliedjobs.component.css']
})
export class AppliedjobsComponent extends PagedListingComponentBase<AppliedJobListDTO> {
  appliedjobs: AppliedJobListDTO[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _appliedJobsService: AppliedJobsServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }


  ngOnInit(): void {
    this.getAllAppliedJobs(1);
  }

  getAllAppliedJobs(creatorUserId: number){
    this._appliedJobsService.getAll(creatorUserId)
    .pipe(
     finalize(() => {
       console.log("Error")
       // finishedCallback();
     })
    )
     .subscribe( data => { 
      console.log(data)
      this.appliedjobs=data.items;
      //this.totalItems=data.totalCount;
    });
   }

  // createAppliedJob(): void {
  //   this.showCreateOrEditUserDialog();
  // }

  // editUser(user: UserDto): void {
  //   this.showCreateOrEditUserDialog(user.id);
  // }

  // public resetPassword(user: UserDto): void {
  //   this.showResetPasswordUserDialog(user.id);
  // }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }

  protected list(
    request: PagedUsersRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    //this._appliedJobsService
      // .getAll(
      //   request.keyword,
      //   request.isActive,
      //   request.skipCount,
      //   request.maxResultCount
      // )
      // .pipe(
      //   finalize(() => {
      //     finishedCallback();
      //   })
      // )
      // .subscribe((result: UserDtoPagedResultDto) => {
      //   this.users = result.items;
      //   this.showPaging(result, pageNumber);
      // });

      this._appliedJobsService.getAll(1)
    .pipe(
     finalize(() => {
       console.log("Error")
       // finishedCallback();
     })
    )
     .subscribe( data => { 
      console.log(data)
      this.appliedjobs=data.items;
      //this.totalItems=data.totalCount;
    });
  }

  protected delete(appliedjob: AppliedJobListDTO): void {
    abp.message.confirm(
      this.l('UserDeleteWarningMessage', appliedjob.creatorUserId),
      undefined,
      (result: boolean) => {
        if (result) {
          this._appliedJobsService.deleteJob(appliedjob.creatorUserId).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }

  // private showResetPasswordUserDialog(id?: number): void {
  //   this._modalService.show(ResetPasswordDialogComponent, {
  //     class: 'modal-lg',
  //     initialState: {
  //       id: id,
  //     },
  //   });
  // }

  // private showCreateOrEditUserDialog(id?: number): void {
  //   let createOrEditUserDialog: BsModalRef;
  //   if (!id) {
  //     createOrEditUserDialog = this._modalService.show(
  //       CreateUserDialogComponent,
  //       {
  //         class: 'modal-lg',
  //       }
  //     );
  //   } else {
  //     createOrEditUserDialog = this._modalService.show(
  //       EditUserDialogComponent,
  //       {
  //         class: 'modal-lg',
  //         initialState: {
  //           id: id,
  //         },
  //       }
  //     );
  //   }

  //   createOrEditUserDialog.content.onSave.subscribe(() => {
  //     this.refresh();
  //   });
  // }
}
