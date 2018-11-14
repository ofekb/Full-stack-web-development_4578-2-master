## Processes and Threads


## CPU Scheduling
Scheduling of processes/work is done to finish the work on time.

Below are different time with respect to a process.

* Arrival Time - Time at which the process arrives in the ready queue.
* Completion Time - Time at which process completes its execution.
* Burst Time - Time required by a process for CPU execution.
* Turn Around Time - Time Difference between completion time and arrival time.
    * Turn Around Time = Completion Time - Arrival Time
* Waiting Time(W.T):** Time Difference between turn around time and burst time.
     * Waiting Time = Turn Around Time - Burst Time

### Why do we need scheduling?
A typical process involves both I/O time and CPU time. In a uniprogramming system like MS-DOS, time spent waiting for I/O is wasted and CPU is free during this time. In multiprogramming systems, one process can use CPU while another is waiting for I/O. This is possible only with process scheduling.


**Different Scheduling Algorithms**
-----------------------------------

_**First Come First Serve (FCFS):**_ Simplest scheduling algorithm that schedules according to arrival times of processes.

_**Shortest Job First(SJF):**_ Process which have the shortest burst time are scheduled first.

_**Shortest Remaining Time First(SRTF):**_ It is preemptive mode of SJF algorithm in which jobs are schedule according to shortest remaining time.

_**Round Robin Scheduling:**_ Each process is assigned a fixed time in cyclic way.

_**Priority Based scheduling (Non Preemptive):**_ In this scheduling, processes are scheduled according to their priorities, i.e., highest priority process is schedule first. If priorities of two processes match, then schedule according to arrival time.

_**Highest Response Ratio Next (HRRN)**_ In this scheduling, processes with highest response ratio is scheduled. This algorithm avoids starvation.

Response Ratio = (Waiting Time + Burst time) / Burst time

_**Multilevel Queue Scheduling:**_ According to the priority of process, processes are placed in the different queues. Generally high priority process are placed in the top level queue. Only after completion of processes from top level queue, lower level queued processes are scheduled.

_**Multi level Feedback Queue Scheduling:**_ It allows the process to move in between queues. The idea is to separate processes according to the characteristics of their CPU bursts. If a process uses too much CPU time, it is moved to a lower-priority queue.

**Some useful facts about Scheduling Algorithms:**  
**1)** FCFS can cause long waiting times, especially when the first job takes too much CPU time.

**2)** Both SJF and Shortest Remaining time first algorithms may cause starvation. Consider a situation when long process is there in ready queue and shorter processes keep coming.

**3)** If time quantum for Round Robin scheduling is very large, then it behaves same as FCFS scheduling.

**4)** SJF is optimal in terms of average waiting time for a given set of processes,i.e., average waiting time is minimum with this scheduling, but problems is, how to know/predict time of next job.


  
## Process:
* An executing instance of a program is called a process.
* Some operating systems use the term ‘task‘ to refer to a program that is being executed.
* A process is always stored in the main memory also termed as the primary memory or random access memory (RAM).
Therefore, a process is termed as an active entity. It disappears if the machine is rebooted.
* Several process may be associated with a same program.
* On a multiprocessor system, multiple processes can be executed in parallel.
* On a single-processor system, though true parallelism is not achieved, a process scheduling algorithm is applied and the processor is scheduled to execute each process one at a time yielding an illusion of concurrency.   

*Example:* Executing multiple instances of the ‘Calculator’ program. Each of the instances are termed as a process.
## Thread:

* A thread is a subset of the process.
It is termed as a ‘lightweight process’, since it is similar to a real process but executes within the context of a process and shares the same resources allotted to the process by the kernel.
* Usually, a process has only one thread of control – one set of machine instructions executing at a time.
* A process may also be made up of multiple threads of execution that execute instructions concurrently.
* Multiple threads of control can exploit the true parallelism possible on multiprocessor systems.
* On a single-processor system, a thread scheduling algorithm is applied and the processor is scheduled to run each thread one at a time.
* All the threads running within a process share the same address space, file descriptors, stack and other process related attributes.
Since the threads of a process share the same memory, synchronizing the access to the shared data within the process gains unprecedented importance.