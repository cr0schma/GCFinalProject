import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { AzBlobService } from '../az-blob.service';
import { AzStorage } from '../az-storage';

declare var window:any;

@Component({
  selector: 'app-az-storage',
  templateUrl: './az-storage.component.html',
  styleUrls: ['./az-storage.component.css']
})
export class AzStorageComponent implements OnInit {
  
  constructor(private azBlobSerice:AzBlobService) {}

  userName: string = this.azBlobSerice.userName
  images: AzStorage[] = [];
  results: AzStorage[] = [];
  showLoader!: boolean;
  formModal:any;
  fileToUpload!: FormData;
  @ViewChild("fileUpload", { static: false }) fileUpload!: ElementRef;
  addProperty!:any;
  tagImage!: string;

  ngOnInit(): void {
    
    this.getImages();
    this.results = this.images;

  }

  getImages(): void {
    this.showLoader = true;
    this.azBlobSerice.getImages()
      .subscribe({
        next: (result: AzStorage[]) => {
          this.images = result
          this.results = this.images
        },
        error: (err: any) => {
          console.error(err);
        },
        complete: () => {
          this.showLoader = false;
        }
      });
  }

  addImage(tag: string) {
    let fileUpload = this.fileUpload.nativeElement;
    fileUpload.onchange = () => {
      this.showLoader = true;
      const file = fileUpload.files[0];
      let formData: FormData = new FormData();
      formData.append("image", file, file.name);
      this.azBlobSerice.addImage(formData, tag).subscribe({
          next: (response: any) => {
            if (response == true) {
              this.getImages();
            }
          },
          error: (err: any) => {
            console.error(err);
            this.showLoader = false;
          },
          complete: () => {
            this.formModal.hide()
          }
        });
    };
    fileUpload.click();
  }

  addTag(tag: string, fileName: string){
    this.showLoader = true;
    this.azBlobSerice.addTag(tag, fileName)
      .subscribe({
        next: (response: any) => {
            this.getImages();
        },
        error: (err: any) => {
          console.error(err);
        },
        complete: () => {
          this.formModal.hide()
        }
      });
  }

  deleteImage(fileName: string) {
    this.showLoader = true;
    this.azBlobSerice.deleteImage(fileName).subscribe({
      next: (response: any) => {
          this.getImages();
      },
      error: (err: any) => {
        console.error(err);
      },
      complete: () => {
        this.showLoader = false;
      }
    });
  }

  filterImages(searchString: string): void {
    this.results = this.images.filter(image => 
        image.tags.includes(searchString.toLowerCase())
    );
    if (!searchString) {
      this.results = this.images;
    }
  }

  openModal(){
    this.formModal = new window.bootstrap.Modal(
      document.getElementById("uploadModal")
    );
    this.formModal.show();
  }

  openTagModal(tagImage: string){
    this.formModal = new window.bootstrap.Modal(
      document.getElementById("tagModalCenter")
    );
    this.tagImage = tagImage;
    this.formModal.show();
  }

}
