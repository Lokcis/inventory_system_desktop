param(
  [string]$out = 'Assets/branch-flow.png'
)

Add-Type -AssemblyName System.Drawing
$bmp = New-Object System.Drawing.Bitmap 800,160
$g = [System.Drawing.Graphics]::FromImage($bmp)
$g.Clear([System.Drawing.Color]::White)
$font = New-Object System.Drawing.Font('Segoe UI',14, [System.Drawing.FontStyle]::Bold)
$brush = New-Object System.Drawing.SolidBrush([System.Drawing.Color]::FromArgb(26,32,44))

# Draw boxes as filled rectangles with borders
$boxPen = New-Object System.Drawing.Pen([System.Drawing.Color]::FromArgb(43,108,176), 3)
$g.FillRectangle([System.Drawing.Brushes]::White, 40, 40, 220, 60)
$g.DrawRectangle($boxPen, 40, 40, 220, 60)
$g.DrawString('feature/<nombre>', $font, $brush, 150, 52, [System.Drawing.StringFormat]::new())

$g.FillRectangle([System.Drawing.Brushes]::White, 290, 40, 220, 60)
$g.DrawRectangle($boxPen, 290, 40, 220, 60)
$g.DrawString('desarrollo', $font, $brush, 400, 52)

$g.FillRectangle([System.Drawing.Brushes]::White, 540, 40, 220, 60)
$g.DrawRectangle($boxPen, 540, 40, 220, 60)
$g.DrawString('main', $font, $brush, 650, 52)

$arrowPen = New-Object System.Drawing.Pen([System.Drawing.Color]::FromArgb(45,55,72),6)
$g.DrawLine($arrowPen,260,70,290,70)
$g.DrawLine($arrowPen,510,70,540,70)

$g.DrawString('Flujo recomendado: feature -> desarrollo -> main', ([System.Drawing.Font]::new('Segoe UI',10)), $brush, 280, 120)

$bmp.Save($out, [System.Drawing.Imaging.ImageFormat]::Png)
$g.Dispose()
$bmp.Dispose()
Write-Output "Saved $out"
