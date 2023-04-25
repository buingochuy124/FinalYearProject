FROM okteto/dotnetcore:3.1
RUN mkdir work
COPY ./output ./work
WORKDIR ./work
ENTRYPOINT ["dotnet", "Smarest.dll"]