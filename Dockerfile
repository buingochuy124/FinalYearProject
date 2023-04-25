FROM okteto/dotnetcore:3.1
RUN mkdir work
COPY ./output ./work
WORKDIR ./work
EXPOSE 80
ENTRYPOINT ["dotnet", "Smarest.dll"]
