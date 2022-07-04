import {
  AfterViewInit,
  Component,
  ElementRef,
  Input,
  OnInit,
  SecurityContext,
  ViewChild,
} from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-video-load',
  templateUrl: './video-load.component.html',
  styleUrls: ['./video-load.component.scss'],
})
export class VideoLoadComponent implements OnInit, AfterViewInit {
  @Input() url: string;
  @Input() type: string;
  @Input() title: string;
  @Input() width: number =640;
  @Input() height: number =267;
  @Input() showControls:boolean = false;

  videoUrl: string | null;
  @ViewChild('videoPlayer', { static: false }) videoplayer: ElementRef;
  isPlay: boolean = false;
  dataSetup = { aspectRatio:`${this.width}:${this.height}`, "playbackRates": [1, 1.5, 2] }

  constructor(private sanitizer: DomSanitizer) {}

  ngOnInit(): void {
    this.videoUrl = this.sanitizer.sanitize(SecurityContext.URL, this.url);
  }

  ngAfterViewInit() {
    const myVideo: any = document.getElementById('my_video_1');
    myVideo.height = this.height;
    myVideo.width = this.width;
    this.changeRatio(myVideo.width,myVideo.height);
  }

  toggleVideo(event: any) {
    this.videoplayer.nativeElement.play();
  }

  playPause() {
    var myVideo: any = document.getElementById('my_video_1');
    if (myVideo.paused) myVideo.play();
    else myVideo.pause();
  }

  makeBig() {
    var myVideo: any = document.getElementById('my_video_1');
    myVideo.width += 20;
    myVideo.height += 20;
    this.changeRatio(myVideo.width,myVideo.height);
  }

  makeSmall() {
    var myVideo: any = document.getElementById('my_video_1');
    myVideo.width -= 20;
    myVideo.height -= 20;
    this.changeRatio(myVideo.width,myVideo.height);
    }

  makeNormal() {
    var myVideo: any = document.getElementById('my_video_1');
    myVideo.width = this.width;
    this.changeRatio(this.width, this.height);
  }

  skip(value: any) {
    let video: any = document.getElementById('my_video_1');
    video.currentTime += value;
  }

  restart() {
    let video: any = document.getElementById('my_video_1');
    video.currentTime = 0;
  }

  changeRatio(width: number,height: number) {
    this.dataSetup.aspectRatio = `${width}:${height}`;
    const myVideo: any = document.getElementById('my_video_1');
    myVideo.dataset.setup =  JSON.stringify(this.dataSetup);
  }
}
