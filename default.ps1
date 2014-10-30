properties {
  $projectName = "MicroLite.Extensions.MiniProfiler"
  $baseDir = Resolve-Path .
  $buildDir = "$baseDir\build"
  $helpDir = "$buildDir\help\"

  $builds = @(
    @{Name = "NET40"; Constants="NET_4_0"; BuildDir="$buildDir\4.0\"; Framework="v4.0"},
    @{Name = "NET45"; Constants="NET_4_5"; BuildDir="$buildDir\4.5\"; Framework="v4.5"}
  )
}

Task Default -depends Build

Task Clean {
  Write-Host "Cleaning $projectName Build Directory" -ForegroundColor Green
  foreach ($build in $builds) {
    $outDir = $build.BuildDir
    Remove-Item -force -recurse $outDir -ErrorAction SilentlyContinue
  }
  Remove-Item -force -recurse $helpDir -ErrorAction SilentlyContinue
  Write-Host
}

Task Build -Depends Clean {
  foreach ($build in $builds) {
    $name = $build.Name
    Write-Host "Building $projectName.$name.sln" -ForegroundColor Green

    $constants = $build.Constants
    $outDir = $build.BuildDir
    $netVer = $build.Framework
    Exec { msbuild "$projectName.$name.sln" "/target:Clean;Rebuild" "/property:Configuration=Release;WarningLevel=1;DefineConstants=$constants;OutDir=$outDir;TargetFrameworkVersion=$netVer" /verbosity:quiet }
  }
  Write-Host
}