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