import { Injectable } from "@angular/core";
import { Observable, of, from, Subject } from "rxjs";

@Injectable()
export class MathService {

    subject = new Subject();

    subjectVersion(numOfCalls) {
        for (let i = 0; i < numOfCalls; i++) {
            setTimeout(() => { this.subject.next(`MathService says: ${i}`); },
            i * 5000);
        }
    }


    fromVersion(): Observable<number> {
        let arr = [1, 2, 3, 4, 5, 6];
        return from(arr);
    }


    ofVersion(): Observable<number[]> {
        return of([1, 2, 3, 4, 5, 6]);
    }

}