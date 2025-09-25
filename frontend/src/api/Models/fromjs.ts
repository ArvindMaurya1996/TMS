import { Login } from "./Login";
import { Task } from "./Task";
import { TokenWrapper } from "./TokenWrapper";
import { User } from "./user";

export class FromJsUtils
{

    static fromJsTask(data: any): Task {
        data = typeof data === 'object' ? data : {};
        let result = new Task();
        result.assigneeId = data.assigneeId;
        result.createdAt = data.createdAt;
        result.creatorId = data.creatorId;

        result.description = data.description;
        result.id = data.id;
        result.priority = data.priority;
        result.status = data.status;
        result.title = data.title;
        result.updatedAt = data.updatedAt;

        return result;

    }

    static fromJsUser(data: any): User {
        data = typeof data === 'object' ? data : {};
        let result = new User();
        result.createdAt = data.createdAt;
        result.email = data.email;
        result.id= data.id;

        result.name = data.name;
        result.password = data.password;
        result.role = data.role;
        
        return result;

    }

    static fromJsTokenWrapper(data: any): TokenWrapper {
        data = typeof data === 'object' ? data : {};
        let result = new TokenWrapper();
        result.Expiration = data.Expiration;
        result.Token = data.Token;
        return result;

    }

    static fromJsLogin(data: any): Login {
        data = typeof data === 'object' ? data : {};
        let result = new Login();
        result.email = data.email;
        result.password= data.password;
        return result;

    }

}