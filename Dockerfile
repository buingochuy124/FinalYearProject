FROM okteto/dotnetcore:3.1
RUN mkdir work
COPY ./output ./work
WORKDIR ./work
RUN dotnet dev-certs https --clean
RUN dotnet dev-certs https --trust
EXPOSE 80
ENTRYPOINT ["dotnet", "Smarest.dll"]
