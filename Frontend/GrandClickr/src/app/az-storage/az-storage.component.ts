import { Component, OnInit} from '@angular/core';
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
  
  images: AzStorage[] = [];
  results: AzStorage[] = [];
  showLoader!: boolean;
  formModal:any;

  ngOnInit(): void {
    this.getImages();
    this.results = this.images
    this.formModal = new window.bootstrap.Modal(
      document.getElementById("exampleModal")
    );
  }

  getImages(): void {
    this.showLoader = true;
    this.azBlobSerice.getImages()
      .subscribe({
        next: (result: AzStorage[]) => {
          this.images = result
          this.results = this.images
        },
        error: (err) => {
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
    this.formModal.show();
  }

  doSomething(){
    this.formModal.hide();
  }

}
