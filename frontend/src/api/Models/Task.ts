import type { TaskStatus } from "./TaskStatus";

export class Task {
    id!: string; // Guid
    title!: string;
    description!: string;
    status!: TaskStatus;
    priority!: string;
  
    assigneeId!: string; // Guid
    creatorId!: string;  // Guid
  
    createdAt!: Date;
    updatedAt!: Date;

  }