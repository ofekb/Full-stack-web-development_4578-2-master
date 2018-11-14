import { Injectable } from '@angular/core';

import { User } from './../models/user';
import { of, Observable } from 'rxjs';

@Injectable()
export class UserService {
    getAll(): Observable<User[]> {
        return of<User[]>([
            {
                id: 1,
                username: 'test',
                password: 'test',
                firstName: 'Test',
                lastName: 'User'
            }
        ]);
    }
}