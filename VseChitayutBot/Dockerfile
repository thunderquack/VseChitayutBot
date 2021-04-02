FROM centos
MAINTAINER ty@pidor.de

RUN yum update -y

RUN dnf install -y https://dl.fedoraproject.org/pub/epel/epel-release-latest-8.noarch.rpm

RUN yum install -y mc traceroute net-tools telnet htop

RUN dnf install -y dotnet-runtime-5.0

RUN dotnet --info

CMD cd /var/vsechitayut && dotnet VseChitayutBot.dll