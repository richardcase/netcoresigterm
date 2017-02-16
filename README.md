# .NET Core & SIGTERM
A demo .NET Core application for running on Linux that shows how to 
workaround .NET Cores support for SIGTERM.

### Background
Docker uses SIGTERM to signal to a process running in a container that
it intends to stop teh container. This gives the process time to 
gracefully shutdown before the container is stopped and the process is
forcibully shutdown (with SIGTERM).

This is essential for Kubernetes as this is how you can update a web service / UI
using a rolling upgrade with zero downtime. Kubernetes/Docker will SIGTERM the container
at which point the hosted service should return failure for the health probe. This will
ensure that no new work is sent to the instance.

### To deploy
1. Clone the repo
2. Edit sigtermtest to ensure the *dir* parameter points to the clone folder
3. Copy sigtermtest to /etc/init.d/
4. Make sigtermtest executable (i.e. chmod +x sigtermtest)
5. As root run:
```bash
/etc/init.d/sigtermtest start
```
6. View the log output of the application by running:
```bash
tail -f /var/log/sigtermtest.log
```
7. Kill the dotnet process using *kill*

You should see the process is signalled and continues to process for 10 seconds.

The init script is based on a template from: https://github.com/fhd/init-script-template