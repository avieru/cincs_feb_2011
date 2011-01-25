$now = get-date
$new_branch_name = "$($now.year)$($now.month)$($now.day)$($now.hour)$($now.minute)"
git add -A
git commit -m "Committing"
git checkout master
git checkout -b $new_branch_name
git pull jp master
echo "new branch name:$new_branch_name"
