# DaprSample
Distributed resilient microservices sample API with dotnet 6 and dapr.
This document is designed to set up a dev environment on a Windows system [Recommended].

## Pre-requisite

- Engineering laptop or desktop computer with **16-64GB** RAM and Windows 10 or later.
- System administrator rights on laptop or desktop computer.

### Install Chocolatey

#### [Chocolatey](https://chocolatey.org/install)

- For existing choco, upgrade it

    ```powershell
        choco upgrade Chocolatey -y
    ```  

- For new installation with windows command prompt [CMD]

    ```command
      #Execute on CMD in admin mode

      @"%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -InputFormat None -ExecutionPolicy Bypass -Command "[System.Net.ServicePointManager]::SecurityProtocol = 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))" && SET "PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin"

     ```

- For new installation with PowerShell

    ```powershell
      #Execute on PowerShell in admin mode

      Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))

    ```  

### Install Dotnet 6 SDK

#### [Dotnet 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

- For manual installation, [download](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) and install it.

- For existing dotnet sdk, upgrade it

  ```powershell
  choco upgrade dotnet-6.0-sdk -y
  ```
  
- With Chocolatey

  ```powershell
  choco install dotnet-6.0-sdk -y
  ```

### Install Git

#### [Git](https://git-scm.com/)

- For manual installation, [download](https://git-scm.com/download/win) and install it.

- For new installation with Chocolatey, [Reference](https://community.chocolatey.org/packages/git).

    ```powershell
    choco install git -y
    ```

### Install WSL

#### [WSL](https://docs.microsoft.com/en-us/windows/wsl/install)

- Install WSL2 on Windows 10

    ```powershell
      #Execute on PowerShell in admin mode
      wsl --install
    ```

- Restart your computer to finish the WSL installation on Windows 10 or later.
- Set up your Linux username and password, [Reference](https://docs.microsoft.com/en-us/windows/wsl/setup/environment#set-up-your-linux-username-and-password).

- Confirm platform

    ```powershell
      #Execute on PowerShell in admin mode
        wsl --list --verbose
        or
        wsl -l -v
    ```

- Enable Windows Subsystem for Linux 2, Ignore if already set

    ```powershell
      #Execute on PowerShell in admin mode
      wsl --set-default-version 2
      or
      wsl --set-version Ubuntu 2
    ```

- [Reference](https://pureinfotech.com/install-windows-subsystem-linux-2-windows-10/) to install WSL2 on windows 10 or later.

### Install Docker Desktop

#### [Docker Desktop](https://docs.docker.com/desktop/install/windows-install/)

- For manual installation, [download](https://docs.docker.com/desktop/install/windows-install/) and install it.

- With Chocolatey, [Docker Desktop](https://community.chocolatey.org/packages/docker-desktop) and [Docker Engine](https://community.chocolatey.org/packages/docker-engine),

  ```powershell
  #Execute on PowerShell in admin mode
  choco install docker-desktop -y
  ```

- After installation,restart your system and run the Docker desktop.

- Enable Kubernetes(**Setting->Kubernetes->Enable Kubernetes**).

  > Note: After installation, keep docker desktop in running state.

### Install Kubernetes cli (kubectl)

### [kubectl](https://kubernetes.io/docs/tasks/tools/)

- For existing kubectl, upgrade it

  ```powershell
  #Execute on PowerShell in admin mode
   choco upgrade Kubernetes-cli -y 

  #Verify installation
   kubectl version --client
  ```

- For new installation.

  ```powershell
  #Execute on PowerShell in admin mode
   choco install kubernetes-cli -y

  #Verify installation
   kubectl version --client
  ```

- [Reference](https://kubernetes.io/docs/tasks/tools/install-kubectl-windows/) document for installation.

### Install Helm cli (helm)

#### [helm](https://helm.sh/)

- For existing htlm, upgrade it

  ```powershell
  #Execute on PowerShell in admin mode
  choco upgrade Kubernetes-helm -y

  #Verify installation
   helm version
  ```

- For new installation.

  ```powershell
  #Execute on PowerShell in admin mode
   choco install kubernetes-helm -y

  #Verify installation
   helm version
  ```

- [Reference](https://helm.sh/docs/intro/install/) document for installation.

### Install MsSqlServer

- Start docker desktop [Ignore if it's already running].  

  ```powershell
  #Execute on PowerShell in admin mode
  docker pull mcr.microsoft.com/mssql/server:2019-latest
  cd C:\install

  #Git clone this:
  git clone https://github.com/microsoft/mssql-docker

  #Navigate to linux based chart.
  cd .\mssql-docker\linux\sample-helm-chart\

  #Helm install this:
  helm install sqlserver . --set sa_password=Welcome@123 --set pvc.StorageClass=hostpath
  #Installed in k8s default namespace
  ```

### Install Sql Server Management Studio(SSMS)

- Manually [download](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16) and install it.

- With Chocolatey.

  ```powershell
  #Execute on PowerShell in admin mode
   choco install ssms -y
  ```

- Start docker desktop [Ignore if it's already running].
- Start SSMS and try to connect with sql server:
    > Server: localhost,1433
    User: sa
    Password: Welcome@123

### Install Visual Studio

#### [Visual Studio](https://visualstudio.microsoft.com/downloads/)

- For manual installation, [download](https://visualstudio.microsoft.com/downloads/) and install it [**Recommended**].

- For new installation with Chocolatey, [Reference](https://community.chocolatey.org/packages/visualstudio2022community).

    ```powershell
    choco install visualstudio2022community
    or
    choco install visualstudio2022community --package-parameters "--allWorkloads --includeRecommended --includeOptional --passive --locale en-US"
    ```

#### Install Windows Terminal

##### [Terminal](https://aka.ms/terminal)

- [Reference](https://docs.microsoft.com/en-us/windows/terminal/install) document to set up it.

#### Install PowerShell 7

##### [PowerShell7](https://docs.microsoft.com/en-us/shows/it-ops-talk/how-to-install-powershell-7)

- For manual installation, [Download](https://docs.microsoft.com/en-us/powershell/scripting/install/installing-powershell-on-windows?WT.mc_id=THOMASMAURER-blog-thmaure&view=powershell-7) and install it.

- With Chocolatey.

  ```powershell
  #Execute on PowerShell in admin mode
   choco install powershell-core -y
  ```

#### Install Github Desktop

##### [Github Desktop](https://desktop.github.com/)

- For manual installation, [download](https://desktop.github.com/) and install it.

- For new installation with Chocolatey, [Reference](https://community.chocolatey.org/packages/github-desktop).

    ```powershell
    choco install github-desktop -y
    ```

- Configure it with your github account.
  > Note: Use any Git UI tool as per your choice.


#### Install Lens for Kubernetes

##### [Lens](https://k8slens.dev/)

- For manual installation, [download](https://k8slens.dev/) and install it.

- For new installation with Chocolatey, [Reference](https://community.chocolatey.org/packages/lens).

     ```powershell
     #Execute on PowerShell in admin mode
    choco install lens -y
    ``` 


### Install the Dapr CLI

#### [Dapr](https://dapr.io/)

- For new installation.

  ```powershell
  #Execute on PowerShell in admin mode
   Set-ExecutionPolicy RemoteSigned -scope CurrentUser;
   powershell -Command "iwr -useb https://raw.githubusercontent.com/dapr/cli/master/install/install.ps1 | iex"


  #Verify installation (run this in new terminal)
   dapr
  ```
- For existing htlm, upgrade it

  ```powershell
  #Execute on PowerShell in admin mode
   dapr upgrade
  ```

## Dapr initialization in self-hosted mode

```powershell
#Execute on PowerShell in admin mode
dapr init
#Verify Dapr version
dapr --version
```
> Here, dapr self-hosted mode initialization created **dapr_redis,dapr_zipkin**. You need to delete them for forever as we will deploy these separately later on.

## Dapr initialization in local K8s

```powershell
#Execute on PowerShell in admin mode
dapr init -k
#Verify Dapr version
dapr status -k
```
## Create namespace in local k8s

```powershell
 kubectl create ns vik
```


