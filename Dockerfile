FROM okteto/dotnetcore:3.1
RUN mkdir work
COPY ./output ./work
WORKDIR ./work
EXPOSE 5000 5001
ENTRYPOINT ["dotnet", "Smarest.dll"]
